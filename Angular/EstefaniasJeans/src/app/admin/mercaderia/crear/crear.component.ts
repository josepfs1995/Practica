import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ToastrService } from "ngx-toastr";
import { Observable } from "rxjs";
import { Categoria } from "src/app/model/Categoria";
import { CategoriaService } from "src/app/services/categoria.service";
import { CrearMercaderia } from "../model/CrearMercaderia";
import { CrearMercaderiaFoto } from "../model/CrearMercaderiaFoto";
import { MercaderiaService } from "../services/mercaderia.service";

@Component({
    selector:"app-crear",
    templateUrl: "crear.component.html"
})
export class CrearComponent implements OnInit{
    formMercaderia!:FormGroup;
    files: File[] = [];
    mercaderia!: CrearMercaderia;
    categorias: Categoria[] = [];
    constructor(private fb:FormBuilder,
        private categoriaService: CategoriaService, 
        private mercaderiaService: MercaderiaService,
        private toastr:ToastrService) {
        
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
    obtenerFiles():Observable<CrearMercaderiaFoto>{
        return new Observable(suscriber => {
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
        if(this.formMercaderia.valid && this.files.length > 0){
            this.mercaderia = Object.assign({}, this.formMercaderia.value);
            this.mercaderia.MercaderiaFoto = [];
            this.obtenerFiles().subscribe(
            success => {this.mercaderia.MercaderiaFoto.push(success);},
            error => {},
            () => {
                this.mercaderiaService.crear(this.mercaderia).subscribe(
                    success => {this.procesarResultado(success)},
                    error => {this.procesarError(error)}
                );
            });
        }
        else{
            this.toastr.error("Por favor, llenar los campos obligatorios");
        }
    }
    procesarResultado(success:any){
        this.toastr.success("Guardado correctamente!");
        this.formMercaderia.reset();
        this.files = [];
    }
    procesarError(fail:any){
        this.toastr.error("Ocurrio un error!");
    }
    onSelect(event:any) {
        this.files.push(...event.addedFiles);
    }
    
    onRemove(event:any) {
        this.files.splice(this.files.indexOf(event), 1);
    }
}