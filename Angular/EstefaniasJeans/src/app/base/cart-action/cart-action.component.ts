import { Component, Input } from "@angular/core";

import { ToastrService } from "ngx-toastr";

import { Mercaderia } from "src/app/mercaderia/models/mercaderia";
import { Favorito } from "src/app/model/Favorito";
import { Carrito } from "src/app/model/Carrito";
import { CarritoService } from "src/app/services/carrito.service";
import { FavoritoService } from "src/app/services/favorito.service";

@Component({
    selector: "app-cart-action",
    templateUrl: "cart-action.component.html"
})
export class CartActionComponent{
    @Input() mercaderia: Mercaderia = {
        Id_Mercaderia: "",
        Nombre: "",
        Descripcion: "",
        MercaderiaFoto: [],
        Categoria: {
            Id_Categoria: '',
            Nombre: ''
        },
        Precio: 0,
        Stock: 0,
        StockRestante: 0
    };
    constructor(private carritoService: CarritoService, private favoritoService: FavoritoService,
            private toastr: ToastrService) {
        
    }
    agregarCarrito():void{
        let carrito: Carrito = new Carrito(this.mercaderia.Id_Mercaderia, this.mercaderia.Nombre, 1, this.mercaderia.Precio, this.mercaderia.MercaderiaFoto.map(result => result.Nombre));
        this.carritoService.agregarAlCarrito(carrito);
        this.toastr.success("Se agrego al carrito correctamente!", "Correcto!!");
    }
    agregarFavorito():void{
        let favorito: Favorito = new Favorito(this.mercaderia.Id_Mercaderia, this.mercaderia.Nombre, this.mercaderia.Precio, this.mercaderia.MercaderiaFoto.map(result => result.Nombre));
        this.favoritoService.agregarFavorito(favorito);
        this.toastr.success("Se guardo como favorito!");
    }
}