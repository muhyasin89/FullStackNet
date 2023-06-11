import { z } from "zod";
import { RegisterData } from "./registerType";

export const ReimburseResponseData = {
  codeStatus: z.number(),
  data: RegisterData,
  message: z.string(),
};
