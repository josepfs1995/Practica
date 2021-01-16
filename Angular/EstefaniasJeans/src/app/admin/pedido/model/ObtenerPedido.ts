import { Persona } from "src/app/autenticacion/model/Persona";
import { PedidoDetalle } from "./PedidoDetalle";

export interface ObtenerPedido{
    Id_Pedido: string,
    Fecha: Date,
    Descripcion:string,
    PrecioTotal:number,
    PedidoDetalle: PedidoDetalle[]
    Persona: Persona
}