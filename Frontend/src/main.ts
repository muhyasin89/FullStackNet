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

import { createPinia } from 'pinia'

const vuetify = createVuetify({
  components,
  directives,
})


const pinia = createPinia()

const app = createApp(App);
app.use(pinia);
app.use(vuetify);
app.use(VueSweetalert2);

app.component('EasyDataTable', Vue3EasyDataTable);

app.mount('#app');
