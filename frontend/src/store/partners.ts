import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { IPartners } from "../types/partners";

const apiUrl = import.meta.env.VITE_API_URL;

export const partners = createApi({
  reducerPath: "partners",
  baseQuery: fetchBaseQuery({
    baseUrl: apiUrl,
  }),

  endpoints: (builder) => ({
    partners: builder.query<IPartners, void>({
      query: () => "/partners",
    }),
  }),
});

export const {
  usePartnersQuery,
} = partners;