import { EnvViteType } from "../interface/ViteEnvType";
import { defineStore } from "pinia";
import { ref } from "vue";

export const useRootStore = defineStore("root", () => {
  const host = ref("");
  const token = ref("");

  const ChangeEnv = (vite_env: EnvViteType) => {
    host.value = vite_env.host;
  };

  const ChangeToken = (tokenResponse: string) => {
    token.value = tokenResponse;
  };

  const header_login = {
    "Content-type": "application/json",
    Authorization: `Token ${token.value}`,
  };

  const GetHeader = () => {
    if (token.value == "") {
      return {
        headers: {
          "Content-type": "application/json",
        },
      };
    } else {
      return {
        headers: header_login,
      };
    }
  };

  const Logout = () => {};

  return {
    host,
    token,
    ChangeEnv,
    GetHeader,
    Logout,
    ChangeToken,
  };
});
