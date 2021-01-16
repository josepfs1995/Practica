import { Component,   OnDestroy,   OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { Carrito } from "src/app/model/Carrito";
import { CarritoService } from "src/app/services/carrito.service";

@Component({
    selector: "app-carrito-icon",
    templateUrl: "carrito-icon.component.html"
})
export class CarritoIconComponent implements OnInit, OnDestroy{
    public carritos:Carrito[] = [];
    public montoTotal:number = 0;
    subscription: Subscription;
    constructor(private carritoService: CarritoService) {
        this.subscription = this.carritoService.suscribirse().subscribe(carritos=>{
            this.carritos = carritos;
            this.obtenerMontoTotal();
        });
    }
    ngOnInit(): void {
        this.carritos = this.carritoService.obtenerCarritos();
        this.obtenerMontoTotal();
    }
    obtenerMontoTotal():void{
        this.montoTotal = 0;
        this.carritos.forEach(item => {
            this.montoTotal += (item.Precio * item.Cantidad);
        })
    }
    eliminarDeCarrito(item:Carrito):void{
        this.carritoService.eliminarDelCarrito(item);
    }
    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }
}