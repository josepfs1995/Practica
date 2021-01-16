import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Slider } from "src/app/base/models/slider";
import { Carrito } from "src/app/model/Carrito";
import { ImagePipe } from "src/app/pipes/ImagePipe";
import { CarritoService } from "src/app/services/carrito.service";
import { environment } from "src/environments/environment";
import { MercaderiaService } from "../services/mercaderia.service";

@Component({
    selector:"app-mercaderia-detalle",
    templateUrl: "mercaderia.detalle.component.html"
})
export class MercaderiaDetalleComponent implements OnInit{

    public mercaderia:any;
    public cargando: boolean= true;
    public boton:boolean=false;
    public mercaderiaFoto: string[] = [];
    public slider: Slider = {
        boton: false,
        width: 350,
        height: 450
    };
    public cantidadPantalon: number = 1;
    public whatsapp:string = `https://wa.me/${environment.numTelefono}?text=Hola, Necesito información sobre este modelo? ${window.location.href}`;

    constructor(private route: ActivatedRoute, 
        private mercaderiaService: MercaderiaService,
        private carritoService: CarritoService,
        private imageFormat: ImagePipe,
        private toastr: ToastrService) {
        
    }
    ngOnInit(): void {
        this.route.params.subscribe(param => {
            this.mercaderiaService.getById(param["id"])
            .subscribe(result => {
                this.mercaderia = result;
                this.mercaderiaFoto = result.MercaderiaFoto.map(result => {
                    return this.imageFormat.transform(result.Nombre, this.mercaderia.Id_Mercaderia)
                });
                this.cargando = false;
            });
        });
    }
    aumentarCantidad():void{
        this.cantidadPantalon += 1;
    }
    restarCantidad():void{
        if( this.cantidadPantalon > 1){
            this.cantidadPantalon -= 1;
        }
    }
    keyDown($event:any):void{
        if((48 > $event.keyCode || $event.keyCode > 57) && (96 > $event.keyCode || $event.keyCode > 105) && ($event.keyCode != 8) && ($event.keyCode != 46)){
            $event.preventDefault();
        }
    }
    keyUp($event:any):void{
        this.cantidadPantalon = $event.target.value !== "" ? parseInt($event.target.value) : 1;
    }
    agregarAlCarrito():void{
        let imagenes: string[] =  this.mercaderia.MercaderiaFoto.map((resultado:any)=>{return resultado.Nombre});
        let carrito : Carrito = new Carrito(this.mercaderia.Id_Mercaderia, this.mercaderia.Nombre, this.cantidadPantalon, this.mercaderia.Precio,imagenes);
        this.carritoService.agregarAlCarrito(carrito);
        this.toastr.success("Se agrego al carrito correctamente!", "Correcto!!");
    }
}