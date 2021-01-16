import { Categoria } from "src/app/model/Categoria";
import { MercaderiaFoto } from "./MercaderiaFoto";

export interface Mercaderia{
    Id_Mercaderia:string;
    Id_Categoria:string;
    Nombre:string;
    Descripcion:string;
    Stock:number;
    StockRestante:number;
    Precio: number;
    Estado: boolean;
    Categoria: Categoria;
    MercaderiaFoto: MercaderiaFoto[];
}