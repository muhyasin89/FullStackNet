import { envViteType } from "../interface/ViteEnvType";
import { defineStore } from "pinia";
import { ref } from "vue";

export const useRootStore = defineStore("root", () => {
    const host = ref("");

    const ChangeEnv = (vite_env: envViteType) => {
        host.value = vite_env.host;
      };
});