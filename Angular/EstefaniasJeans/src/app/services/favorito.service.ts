import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { Favorito } from "../model/Favorito";

@Injectable({
    providedIn: "root"
})
export class FavoritoService{

    public subject = new Subject<Favorito[]>();

    suscribirse():Observable<Favorito[]>{
        return this.subject.asObservable();
    }
    obtenerFavoritos(): Favorito[]{
        let favoritos: string  = localStorage.getItem("Favorito") || "";
        return favoritos === "" ? [] : JSON.parse(favoritos) ;
    } 
    guardarEnSession(favoritos: Favorito[]):void{
        localStorage.setItem("Favorito", JSON.stringify(favoritos));
    }
    agregarFavorito(favorito: Favorito): void{
        let favoritos: Favorito[] = this.obtenerFavoritos();
        if(this.obtenerFavorito(favorito.Id_Mercaderia) === undefined){
            favoritos.push(favorito);
            this.guardarEnSession(favoritos);
            debugger;
            this.subject.next(favoritos);
        }
    }
    obtenerFavorito(id_Mercaderia: string):Favorito | undefined{
        let favoritos: Favorito[] = this.obtenerFavoritos();
        return favoritos.find(x=>x.Id_Mercaderia == id_Mercaderia);
    }
    eliminarDelCarrito(pedido:Favorito): void{
        if(pedido != undefined){
            let favoritos: Favorito[] = this.obtenerFavoritos();
            let indice: number = favoritos.findIndex(x=> x.Id_Mercaderia == pedido.Id_Mercaderia);
            favoritos.splice(indice, 1);
            this.guardarEnSession(favoritos);
            this.subject.next(favoritos);
        }
    }
    limpiarCarrito():void{
        localStorage.removeItem("Favorito");
        this.subject.next([]);
    }
}