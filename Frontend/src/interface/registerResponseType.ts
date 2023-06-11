import { z } from "zod";
import { RegisterData, RegisterType } from "./RegisterType";

export const RegisterResponseData = {
  codeStatus: z.number(),
  data: RegisterData,
  message: z.string(),
};


export interface RegisterResponseType{
  codeStatus: number,
  data: RegisterType,
  message: string,
}