import { ReactNode } from "react";
import Header from "../Header";
import Footer from "../Footer";

interface IProps {
  children: ReactNode;
}

const Main = ({ children }: IProps) => {
  return (
    <div style={{ maxWidth: 1440, margin: "auto", width: "75%" }}>
      <Header />
      {children}
      <Footer />
    </div>
  );
};

export default Main;
