import { Pipe, PipeTransform } from "@angular/core";
import { environment } from "src/environments/environment";
@Pipe({
    name: "image"
})
export class ImagePipe implements PipeTransform{
    transform(value: string, folder:string = "") {
        return environment.urlService + "/" + folder + '/'+ value;
    }
}