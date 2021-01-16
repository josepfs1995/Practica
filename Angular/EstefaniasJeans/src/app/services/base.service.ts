import { HttpErrorResponse, HttpHeaders } from "@angular/common/http"
import { throwError } from "rxjs";
import { environment } from "src/environments/environment";

export abstract class BaseService{
    protected UrlServiceV1:string= environment.urlService+ "/api/";
    // protected UrlServiceV1:string="http://localhost:60938/api/";

    protected obtenerHeaderJson(agregarToken:boolean = false, token:string = ""){
        let headers : HttpHeaders = new HttpHeaders({
            "Content-Type": "application/json",
            "Authorization": agregarToken ? "Bearer "+ token : ""
        });
        return {
            headers : headers
        }
    }
    protected obtenerHeaderJsonDelete(agregarToken:boolean = false, token:string = ""){
        let headers : HttpHeaders = new HttpHeaders({
            "Authorization": agregarToken ? "Bearer "+ token : ""
        });
        return {
            headers : headers
        }
    }
    protected extraerData(response:any):any{
        if(response.CodigoError > 0)
        {
            this.manejarError(response);
        }
        return response.Data || {};
    }
    protected serviceError(response: Response|any){
        debugger;
        let customError: string[] = [];
        if(response instanceof HttpErrorResponse){
            if(response.statusText === "Unknown Error"){
                customError.push("Ocurrio un error");
                response.error.Errors = customError;
            }
        }
        return throwError(response);
    }

    protected manejarError(response:any){
        response.MensajeError.forEach((error:any) => {
            console.log(error);
        })
    }
}