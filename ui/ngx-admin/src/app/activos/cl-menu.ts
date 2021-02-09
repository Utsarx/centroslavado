import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'Punto de venta',
    icon: 'shopping-cart-outline',
    link: '/terminal',
    home: true,
  },
  {
    title: 'Reportes',
    icon: 'bar-chart-2-outline',
    link: '',
  },  
  {
    title: 'OPCIONES',
    group: true,
  },
  {
    title: 'Administración',
    icon: 'layout-outline',
    children: [
      {
        title: 'Empresas',
        link: '/Empresas',
      },
      {
        title: 'Centros de lavado',
        link: '/centros',
      },
      {
        title: 'Servicios',
        link: '/categorias',
      },
    ],
  },
];
