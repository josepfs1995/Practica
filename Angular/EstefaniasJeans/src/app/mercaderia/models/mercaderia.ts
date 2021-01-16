import { Categoria } from "src/app/model/Categoria";
import { MercaderiaFoto } from "./mercaderia-foto";

export interface Mercaderia{
    Id_Mercaderia:string;
    Nombre:string;
    Descripcion:string;
    Stock:number;
    StockRestante:number;
    Precio: number;
    Categoria: Categoria;
    MercaderiaFoto: MercaderiaFoto[];
}