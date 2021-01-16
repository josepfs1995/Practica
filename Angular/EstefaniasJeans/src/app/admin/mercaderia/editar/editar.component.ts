import { AfterViewInit, Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Observable } from "rxjs";
import { MercaderiaFoto } from "src/app/mercaderia/models/mercaderia-foto";
import { Categoria } from "src/app/model/Categoria";
import { CategoriaService } from "src/app/services/categoria.service";
import { environment } from "src/environments/environment";
import { CrearMercaderiaFoto } from "../model/CrearMercaderiaFoto";
import { EditarMercaderia } from "../model/EditarMercaderia";
import { MercaderiaService } from "../services/mercaderia.service";

@Component({
    selector: "app-editar",
    templateUrl: "editar.component.html"
})
export class EditarComponent implements OnInit, AfterViewInit{
    mercaderia!:EditarMercaderia;
    files: File[] = [];
    formMercaderia!: FormGroup;
    categorias: Categoria[] = [];
    id_Mercaderia:string = "";
    mercaderiaFoto: any[] = [];
    constructor(private router: ActivatedRoute, 
        private mercaderiaService: MercaderiaService,
        private categoriaService: CategoriaService,
        private fb:FormBuilder,
        private toastr: ToastrService) {
        
    }  
    ngOnInit(): void {
        this.formMercaderia = this.fb.group({
            Id_Categoria: ["-1", Validators.required],
            Nombre: ['', Validators.required],
            Descripcion:[''],
            Stock: ['', Validators.required],
            Precio: ['', Validators.required]
        });
        this.categoriaService.get().subscribe((resultado) => {
            this.categorias = resultado;
        });
    }
    ngAfterViewInit(): void {
        this.router.params.subscribe(
            param => {
                this.mercaderiaService.getById(param["id"]).subscribe(
                    success => {this.procesarResultado(success)}
                )
            })
    }
    procesarResultado(success: any):void{
        console.log(success);
        this.id_Mercaderia = success.Id_Mercaderia;
        this.formMercaderia = this.fb.group({
            Id_Categoria: [success.Id_Categoria, Validators.required],
            Nombre: [success.Nombre, Validators.required],
            Descripcion:[success.Descripcion],
            Stock: [success.Stock, Validators.required],
            Precio: [success.Precio, Validators.required]
        });
        this.mercaderiaFoto = success.MercaderiaFoto;
    }
    obtenerFiles():Observable<any>{
        return new Observable(suscriber => {
            if(this.files.length === 0) suscriber.complete();
            this.files.forEach((file: File, index:number) =>{
                let fileReader:FileReader = new FileReader();
                fileReader.onloadend = (e) =>{
                    suscriber.next({
                        Nombre: file.name,
                        Base64: fileReader.result?.toString().replace(/^data:image\/[a-z]+;base64,/, "")
                    });
                    if(index === this.files.length - 1)
                        suscriber.complete();
                }
                fileReader.readAsDataURL(file);
            });
        })
    }
    guardar():void{
        if(this.formMercaderia.valid && (this.files.length > 0 || this.mercaderiaFoto.length > 0)){
            this.mercaderia = Object.assign({}, this.formMercaderia.value);
            this.mercaderia.Id_Mercaderia = this.id_Mercaderia;
            this.mercaderia.MercaderiaFoto = [];
            this.obtenerFiles().subscribe(
            success => {this.mercaderia.MercaderiaFoto.push(success);},
            error => {},
            () => {
                this.mercaderia.MercaderiaFoto.push(...this.mercaderiaFoto);
                this.mercaderiaService.editar(this.mercaderia).subscribe(
                    success => {this.toastr.success("Guardado correctamente!")},
                    error => {this.toastr.error("Ocurrio un error")}
                );
            });
        }
        else{
            this.toastr.error("Por favor, llenar los campos obligatorios");
        }
    }
    onSelect(event:any) {
        this.files.push(...event.addedFiles);
    }
    onRemove(event:any) {
        this.files.splice(this.files.indexOf(event), 1);
    }
    eliminarFoto(id:string):void{
        let indice: number = this.mercaderiaFoto.findIndex(x=>x.Id_MercaderiaFoto === id);
        this.mercaderiaFoto.splice(indice, 1);
    }
}