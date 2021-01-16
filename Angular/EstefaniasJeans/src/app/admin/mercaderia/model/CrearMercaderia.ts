import { CrearMercaderiaFoto } from "./CrearMercaderiaFoto";

export interface CrearMercaderia{
    Id_Persona:string;
    Id_Categoria:string;
    Nombre: string;
    Descripcion: string,
    Stock: number;
    Precio: number;
    MercaderiaFoto: CrearMercaderiaFoto[]
}