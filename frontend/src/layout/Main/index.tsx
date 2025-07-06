import { ReactNode } from "react";
import Header from "../Header";
import Footer from "../Footer";
import style from "./index.module.scss";
interface IProps {
  children: ReactNode;
}

const Main = ({ children }: IProps) => {
  return (
    <div className={style.wrapper}>
      <Header />
      {children}
      <Footer />
    </div>
  );
};

export default Main;
