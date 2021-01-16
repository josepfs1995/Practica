import { Component, OnInit } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { Carrito } from "src/app/model/Carrito";
import { Pedido } from "src/app/admin/pedido/model/Pedido";
import { PedidoDetalle } from "src/app/admin/pedido/model/PedidoDetalle";
import { PedidoService } from "src/app/admin/pedido/services/pedido.service";
import { CarritoService } from "src/app/services/carrito.service";
import { TokenService } from "src/app/services/token.service";
import { environment } from "src/environments/environment";
import { Router } from "@angular/router";

@Component({
    selector:"app-carrito",
    templateUrl: "carrito.component.html"
})
export class CarritoComponent implements OnInit{
    public carritos: Carrito[] = [];
    public precioTotal = 0;
    public estaConectado = false;
    constructor(private router: Router,
                private carritoService: CarritoService,
                private pedidoService: PedidoService,
                private tokenService:TokenService,
                private toastr: ToastrService) {
            console.log();
    }
    ngOnInit(): void {
        this.obtenerCarritos();
        this.estaConectado = this.tokenService.estaConectado();
    }
    limpiarCarrito():void{
        this.carritoService.limpiarCarrito();
        this.obtenerCarritos();
    }
    eliminarDeCarrito(item:Carrito):void{
        this.carritoService.eliminarDelCarrito(item);
        this.obtenerCarritos();
    }
    obtenerCarritos():void{
        this.carritos = this.carritoService.obtenerCarritos();
        this.obtenerPrecioTotal();
    }
    keyDown($event:any):void{
        if((48 > $event.keyCode || $event.keyCode > 57) && (96 > $event.keyCode || $event.keyCode > 105) && ($event.keyCode != 8) && ($event.keyCode != 46)){
            $event.preventDefault();
        }
    }
    keyUp($event:any, item: Carrito):void{
       let valor:number = $event.target.value;
       item.Cantidad = valor;
       this.carritoService.modificarCarrito(item);
       this.obtenerPrecioTotal();
    }
    obtenerPrecioTotal():void{
        this.precioTotal = 0;
        this.carritos.forEach(value => {
            this.precioTotal += value.Cantidad  * value.Precio;
        });
    }
    generarPedido():void{
        if(this.carritos.length > 0){
            let pedidoDetalle: PedidoDetalle[] = [];
            this.carritos.forEach(x=>{
                pedidoDetalle.push({
                    Id_Mercaderia: x.Id_Mercaderia,
                    Cantidad: x.Cantidad,
                    Precio: x.Precio,
                    PrecioTotal: x.Precio * x.Cantidad,
                    Id_Pedido: null,
                    Id_PedidoDetalle : null,
                    Mercaderia:null
                });
            })
            let pedido: Pedido  = {
                Descripcion: '',
                PedidoDetalle: pedidoDetalle
            }
            this.pedidoService.crear(pedido).subscribe(result =>{
                this.toastr.success("Se guardó correctamente").onHidden.subscribe(
                    () => {
                        console.log("cerro");
                    }
                );
                this.carritoService.limpiarCarrito();
                this.carritos = [];
                let whatsapp:string =  `https://wa.me/${environment.numTelefono}?text=Hola, He generado un pedido de S/. ${this.precioTotal}!!! ${window.location.href}`;
                window.open(whatsapp, "_blank");
            });
        }
    }
    
}