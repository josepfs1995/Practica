import { Pipe, PipeTransform } from "@angular/core";
@Pipe({
    name: "orderBy"
})
export class OrderByPipe implements PipeTransform{
    transform(value: any, property:string, ascendente: boolean = true) {
        value.sort((a:any, b:any) => {
            if(a[property] > b[property]){
                return ascendente ? 1 : -1;
            }
            if (a[property] < b[property]) {
                return ascendente ? -1 : 1;
            }
            return 0;
        })
       return value;
    }
}
