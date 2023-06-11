import { defineStore } from "pinia";
import { ref } from "vue";

export const useAuthStore = defineStore("auth", () => {
    const isAuthenticated = ref(false);
    const changeAuthenticated = (val:boolean) =>{
        isAuthenticated.value = val;
    }

    return {
        isAuthenticated,
        changeAuthenticated
    }
});
