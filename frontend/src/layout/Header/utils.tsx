import {
  ABOUT_PATH,
  CONTACT_PATH,
  EQUIPMENT_PATH,
  PORTFOLIO_PATH,
  PROJECT_PATH,
  SERVICES_PATH,
} from "../../utils/routes";

export interface IMenuData {
  children?: Array<{ id: number; value: string; link: string; ref?: any }>;
  id: number;
  value: string;
  link: string;
}

export const menuData = [
  {
    id: 1,
    value: "Haqqımızda",
    link: ABOUT_PATH,
    children: [
      {
        id: 10,
        value: "Haqqımızda",
        link: ABOUT_PATH,
      },
      {
        id: 11,
        value: "Lisenziyalar",
        link: ABOUT_PATH,
        ref: "license",
      },
      {
        id: 12,
        value: "KSƏTƏMM",
        link: ABOUT_PATH,
        ref: "iso",
      },
      {
        id: 13,
        value: "Tövsiyyə məktubları",
        link: ABOUT_PATH,
        ref: "recommendation",
      },
      {
        id: 14,
        value: "Texnika və avadanlıqlar",
        link: EQUIPMENT_PATH,
      },
    ],
  },
  {
    id: 2,
    value: "Xidmətlər",
    link: SERVICES_PATH,
  },
  {
    id: 3,
    value: "Portfolio",
    link: PORTFOLIO_PATH,
    children: [
      {
        id: 10,
        value: "Layihələrimiz",
        link: PROJECT_PATH,
      },
    ],
  },
  {
    id: 4,
    value: "Əlaqə",
    link: CONTACT_PATH,
  },
];

export const optionsData = [
  {
    key: 1,
    label: "Az",
  },
  {
    key: 2,
    label: "En",
  },
];
