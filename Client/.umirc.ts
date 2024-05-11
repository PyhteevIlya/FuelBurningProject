import { defineConfig } from '@umijs/max';

export default defineConfig({
  antd: {},
  access: {},
  model: {},
  initialState: {},
  request: {},

 routes: [
  {
    path: '/',
    component: './index',
  },
  {
    path: '/raschet_gas_fuel',
    component: './raschet_gas_fuel',
  },
  {
    path: '/raschet_liquid_fuel',
    component: './raschet_liquid_fuel',
  },
  {
    path: '/report_gas/:id',
    component: './report_gas/[id]',
  },
  {
    path: '/report_liquid/:id',
    component: './report_liquid/[id]',
  },
  {
    path: '/rezult_gas/:id',
    component: './rezult_gas/[id]',
  },
  {
    path: '/rezult_liquid/:id',
    component: './rezult_liquid/[id]',
  },
  {
    path: '/create/create_raschet_gas',
    component: './create/create_raschet_gas',
  },
  {
    path: '/create/create_raschet_liquid',
    component: './create/create_raschet_liquid',
  },
  {
    path: '/edit_raschet_gas/:id',
    component: './edit_raschet_gas/[id]',
  },
  {
    path: '/edit_raschet_liquid/:id',
    component: './edit_raschet_liquid/[id]',
  },
],

  npmClient: 'npm',
});