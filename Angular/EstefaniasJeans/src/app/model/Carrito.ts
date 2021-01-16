export class Carrito{
    Id_Mercaderia: string;
    Nombre: string;
    Cantidad: number;
    Images: string[];
    Precio: number;
    constructor(id_Mercaderia: string, nombre:string, cantidad:number, precio:number, images:string[]) {
        this.Id_Mercaderia = id_Mercaderia;
        this.Cantidad = cantidad;
        this.Nombre = nombre;
        this.Images = images;
        this.Precio = precio;
    }
}