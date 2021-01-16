import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { Carrito } from "../model/Carrito";

@Injectable({
    providedIn: "root"
})
export class CarritoService{

    public subject = new Subject<Carrito[]>();

    suscribirse():Observable<Carrito[]>{
        return this.subject.asObservable();
    }
    obtenerCarritos(): Carrito[]{
        let carrito: string  = sessionStorage.getItem("Carrito") || "";
        return carrito === "" ? [] : JSON.parse(carrito) ;
    } 
    guardarEnSession(carrito: Carrito[]):void{
        sessionStorage.setItem("Carrito", JSON.stringify(carrito));
    }
    agregarAlCarrito(carrito: Carrito): void{
        let carritos: Carrito[] = this.obtenerCarritos();
        let indice: number = carritos.findIndex(x=> x.Id_Mercaderia == carrito.Id_Mercaderia);
        if(indice > -1){
            carritos[indice].Cantidad += carrito.Cantidad;
        }
        else{
            carritos.push(carrito);
        }
        this.guardarEnSession(carritos);
        this.subject.next(carritos);
    }
    modificarCarrito(carrito: Carrito):void{
        let carritos: Carrito[] = this.obtenerCarritos();
        let indice: number = carritos.findIndex(x=> x.Id_Mercaderia == carrito.Id_Mercaderia);
        carritos[indice] = carrito;
        this.guardarEnSession(carritos);
        this.subject.next(carritos);
    }
    obtenerCarrito(id_Mercaderia: string):Carrito | undefined{
        let carritos: Carrito[] = this.obtenerCarritos();
        return carritos.find(x=>x.Id_Mercaderia == id_Mercaderia);
    }
    eliminarDelCarrito(carrito:Carrito): void{
        if(carrito != undefined){
            let carritos: Carrito[] = this.obtenerCarritos();
            let indice: number = carritos.findIndex(x=> x.Id_Mercaderia == carrito.Id_Mercaderia && x.Cantidad == carrito.Cantidad);
            carritos.splice(indice, 1);
            this.guardarEnSession(carritos);
            this.subject.next(carritos);
        }
    }
    limpiarCarrito():void{
        sessionStorage.removeItem("Carrito");
        this.subject.next([]);
    }
}