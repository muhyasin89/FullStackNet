import { z } from "zod";
import { RegisterData } from "./RegisterType";

export const ReimburseResponseData = {
  codeStatus: z.number(),
  data: RegisterData,
  message: z.string(),
};
