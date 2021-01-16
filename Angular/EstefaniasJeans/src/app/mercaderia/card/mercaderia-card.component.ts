import { Component, OnInit } from "@angular/core";
import { ImagePipe } from "src/app/pipes/ImagePipe";
import { Mercaderia } from "../models/mercaderia";
import { MercaderiaFoto } from "../models/mercaderia-foto";
import { MercaderiaService } from "../services/mercaderia.service";
@Component({
    selector:"app-mercaderia-card",
    templateUrl:"mercaderia-card.component.html",

})
export class MercaderiaCardComponent implements OnInit{
    
    public mercaderias: Mercaderia[]= [];
    constructor(private _mercaderiaService:MercaderiaService) {
        
    }
    ngOnInit(): void {
        this._mercaderiaService.get()
        .subscribe(result => {
            this.mercaderias = result;
        })
    }
}