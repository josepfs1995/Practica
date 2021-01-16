import { CrearMercaderiaFoto } from "./CrearMercaderiaFoto";

export interface EditarMercaderia{
    Id_Mercaderia:string;
    Id_Persona:string;
    Id_Categoria:string;
    Nombre: string;
    Descripcion: string,
    Stock: number;
    Precio: number;
    MercaderiaFoto: CrearMercaderiaFoto[]
}