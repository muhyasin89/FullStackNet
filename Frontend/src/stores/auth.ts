import { defineStore } from "pinia";
import { ref } from "vue";
import { RegisterFormType } from "../interface/RegisterFormType";

export const useAuthStore = defineStore("auth", () => {
    const isAuthenticated = ref(false);
    const changeAuthenticated = (val:boolean) =>{
        isAuthenticated.value = val;
    }

    const registerData: RegisterFormType = {
        username: "",
        password: "",
        confirm_password: "",
        name: "",
        email: "",
        phoneNumber: "",
        dob: "",
    }
 
    return {
        registerData,
        isAuthenticated,
        changeAuthenticated
    }
});
