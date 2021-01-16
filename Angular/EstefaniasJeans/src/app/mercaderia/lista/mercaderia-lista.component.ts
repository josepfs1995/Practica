import { AfterViewInit, Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Categoria } from "src/app/model/Categoria";
import { ImagePipe } from "src/app/pipes/ImagePipe";
import { OrderByPipe } from "src/app/pipes/OrderByPipe";
import { CategoriaService } from "src/app/services/categoria.service";
import { Mercaderia } from "../models/mercaderia";
import { MercaderiaFoto } from "../models/mercaderia-foto";
import { MercaderiaService } from "../services/mercaderia.service";

@Component({
    selector: "app-mercaderia-lista",
    templateUrl: "mercaderia-lista.component.html"
})
export class MercaderiaListaComponent implements OnInit{
    public mercaderias: Mercaderia[] = [];
    public categorias: Categoria[] = [];
    public filtrados: Mercaderia[] = [];
    public isCollapsed: boolean = false;
    public filtrosCategoria: string[] = [];

    @ViewChildren("chk") Checks !: QueryList<ElementRef>;
    constructor(private mercaderiaService: MercaderiaService, 
                private imageFormat: ImagePipe,
                private orderBy: OrderByPipe,
                private categoriaService: CategoriaService,
                private route: ActivatedRoute) {
    }
    ngOnInit(): void {
        if(this.route.snapshot.data["filtro"] !== undefined){
            this.filtrosCategoria = this.route.snapshot.data["filtro"];
        }

        this.mercaderiaService.get().subscribe(result => {
            this.mercaderias = result;
            this.filtrados = this.mercaderias;
            if(this.filtrosCategoria.length > 0){
                this.filtrados = [];
                this.mercaderias.forEach(x=>{
                    if(this.filtrosCategoria.indexOf(x.Categoria.Id_Categoria) > -1){
                        this.filtrados.push(x);
                    }
                });
            }
        });
        this.categoriaService.get().subscribe(result => {
            this.categorias = result;
        });
    }
    ordenarLista(event:any):void{
        let value = event.target.value;
        this.filtrados = this.orderBy.transform(this.filtrados, "Precio", value === "True" ? true : false);
    }
    obtenerFiltrosCategoria():void{
        this.filtrosCategoria = [];
        this.Checks.forEach(item => {
            let categoria:string = item.nativeElement.getAttribute("data-categoria");
            if(item.nativeElement.checked === true){
                this.filtrosCategoria.push(categoria);
            }
        });
    }
    filtrar():void{
        if(this.filtrosCategoria.length > 0)
        {
            this.filtrados = [];
            this.mercaderias.forEach(x=>{
                if(this.filtrosCategoria.indexOf(x.Categoria.Id_Categoria) > -1){
                    this.filtrados.push(x);
                }
            });
        }
        else
        {
            this.filtrados = this.mercaderias;
        }
    }
}