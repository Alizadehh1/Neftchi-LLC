import { createSlice, PayloadAction } from "@reduxjs/toolkit";

// Read from localStorage (safe fallback)
const getInitialLanguage = (): 1 | 2 => {
  const lang = localStorage.getItem("language");
  return lang === "2" ? 2 : 1; // default to 1 (e.g. Azerbaijani)
};

interface GlobalState {
  target: string | null;
  language: 1 | 2; // 1 = AZ, 2 = EN
}

const initialState: GlobalState = {
  target: null,
  language: getInitialLanguage(),
};

const global = createSlice({
  name: "global",
  initialState,
  reducers: {
    setScrollTarget: (state, action: PayloadAction<string | null>) => {
      state.target = action.payload;
    },
    setLanguage: (state, action: PayloadAction<1 | 2>) => {
      state.language = action.payload;
      localStorage.setItem("language", String(action.payload)); // persist to localStorage
    },
  },
});

export const { setScrollTarget, setLanguage } = global.actions;
export default global.reducer;
