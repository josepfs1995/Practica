import { Claim } from "./Claim";

export interface UsuarioToken{
  Id:string;
  Email:string
  Claims:Claim[]
}