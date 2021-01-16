import { UsuarioToken } from "./UsuarioToken";

export interface UsuarioRespuesta{
  AccessToken:string,
  ExpiresIn: number,
  UsuarioToken:UsuarioToken
}