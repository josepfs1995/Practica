import { Mercaderia } from "src/app/mercaderia/models/mercaderia";

export interface PedidoDetalle{
    Id_PedidoDetalle:string | null,
    Id_Pedido: string | null,
    Id_Mercaderia:string,
    Cantidad: number,
    Precio:number,
    PrecioTotal:number
    Mercaderia:Mercaderia | null
}