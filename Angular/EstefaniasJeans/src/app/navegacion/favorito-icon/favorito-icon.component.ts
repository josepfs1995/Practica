import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { Favorito } from "src/app/model/Favorito";
import { FavoritoService } from "src/app/services/favorito.service";

@Component({
    selector: "app-favorito-icon",
    templateUrl: `favorito-icon.component.html`
})
export class FavoritoIconComponent implements OnInit, OnDestroy{
    public favoritos:Favorito[] = [];
    public montoTotal:number = 0;
    subscription: Subscription;
    constructor(private favoritoService: FavoritoService) {
        this.subscription = this.favoritoService.suscribirse().subscribe(favoritos=>{
            debugger;
            this.favoritos = favoritos;
        });
    }
    ngOnInit(): void {
        this.favoritos = this.favoritoService.obtenerFavoritos();
        
    }
    
    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }
}