import { z } from "zod";

export const RegisterData = ({
    id: z.string(),
    username: z.string(),
    name: z.string(),
    email: z.string(),
    phoneNumber: z.string(),
    dateOfBirth: z.string(),
    profilePicture: z.string(),
    isLocked: z.boolean(),
    isDelete: z.boolean(),
    createdDate: z.string(),
    createdBy: z.string(),
    updatedDate: z.string()
});

export interface RegisterType {
    id: string,
    username: string,
    name: string,
    email: string,
    phoneNumber: string,
    dateOfBirth: string,
    profilePicture: string,
    isLocked: boolean,
    isDelete: boolean,
    createdDate: string,
    createdBy: string,
    updatedDate: string
}