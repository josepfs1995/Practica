export class Favorito{
    Id_Mercaderia: string;
    Nombre: string;
    Images: string[];
    Precio: number;
    constructor(id_Mercaderia: string, nombre:string, precio:number, images:string[]) {
        this.Id_Mercaderia = id_Mercaderia;
        this.Nombre = nombre;
        this.Images = images;
        this.Precio = precio;
    }
}