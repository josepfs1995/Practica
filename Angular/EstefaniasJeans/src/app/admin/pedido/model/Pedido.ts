import { Persona } from "src/app/autenticacion/model/Persona";
import { PedidoDetalle } from "./PedidoDetalle";

export interface Pedido{
    Descripcion:string,
    PedidoDetalle: PedidoDetalle[]
}