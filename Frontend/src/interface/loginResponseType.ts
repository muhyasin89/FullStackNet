import { z } from "zod";
export const ReimburseResponseData = {
  codeStatus: z.number(),
  username: z.string(),
  expiredTime: z.string(),
  token: z.string(),
  message: z.string(),
};
