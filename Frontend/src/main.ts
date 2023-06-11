import { createApp } from 'vue'
import './style.css'
import App from './App.vue'

// Vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

// Vue3 data table
import Vue3EasyDataTable from 'vue3-easy-data-table';
import 'vue3-easy-data-table/dist/style.css';

// Sweet Alert
import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';

import { VueQueryPlugin } from "vue-query";

import { createPinia } from 'pinia';

import { faCoffee,  faSearch } from '@fortawesome/free-solid-svg-icons'

library.add(faCoffee)
library.add(faSearch)
/* import the fontawesome core */
import { library } from '@fortawesome/fontawesome-svg-core'

import LoadingComponent from "./components/LoadingComponent.vue";

import router from './router';

import VueDatePicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css'

const vuetify = createVuetify({
  components,
  directives,
})


const pinia = createPinia()

const app = createApp(App);
app.use(router);
app.use(pinia);
app.use(vuetify);
app.use(VueSweetalert2);

app.use(VueQueryPlugin);

app.component('EasyDataTable', Vue3EasyDataTable);
app.component('LoadingComponent', LoadingComponent);
app.component('VueDatePicker', VueDatePicker);

app.mount('#app');
