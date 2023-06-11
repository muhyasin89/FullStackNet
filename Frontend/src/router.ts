import { RouteRecordRaw } from "vue-router";
import { createWebHistory, createRouter } from "vue-router";
import { useAuthStore } from "./stores/auth";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    alias: "/",
    name: "home",
    component: () => import("./pages/HomeView.vue"),
  },
  {
    path: "/login",
    alias: "/login",
    name: "login",
    component: () => import("./pages/auth/LoginView.vue"),
  },
  {
    path: "/register",
    alias: "/register",
    name: "register",
    component: () => import("./pages/auth/RegisterView.vue"),
  },

  {
    path: "/users",
    alias: "/users",
    name: "users",
    component: () => import("./pages/users/UserView.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

router.beforeEach((to, from, next) => {
    const authStore = useAuthStore();
  if (
    to.matched.some((record) => record.meta.requiresLogin) &&
    authStore.isAuthenticated == false
  ) {
    next("/login");
  } else {
    next();
  }
});

export default router;
