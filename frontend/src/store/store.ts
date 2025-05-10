import { configureStore } from "@reduxjs/toolkit";
import scrollReducer from "./global";
import { setupListeners } from "@reduxjs/toolkit/query";
import { partners } from "./partners";

export const store = configureStore({
  reducer: {
    scroll: scrollReducer,
    [partners.reducerPath]: partners.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(partners.middleware),
});

setupListeners(store.dispatch);

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
