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

  const HeaderLogin = {
    "Content-type": "application/json",
    Authorization: `Bearer ${token.value}`,
  };

  const GetHeaderLogin = () =>{
    return HeaderLogin;
  }

  const GetHeader = () => {
    if (token.value == "") {
      return {
        headers: {
          "Content-type": "application/json",
        },
      };
    } else {
      return {
        headers: HeaderLogin,
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
    GetHeaderLogin
  };
});
