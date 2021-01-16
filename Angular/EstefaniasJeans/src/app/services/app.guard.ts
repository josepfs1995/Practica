import { Injectable } from "@angular/core";
import { CanLoad, Route} from "@angular/router";
import { TokenService } from "./token.service";

@Injectable()
export class AuthGuard implements CanLoad {
  constructor(private tokenSerice:TokenService) {
    
  }
  canLoad(route: Route):boolean {
   return this.tokenSerice.esAdmin();
  }

}