import { Spin } from "antd";
import style from "./Loading.module.scss";

const Loading = () => {
  return (
    <div className={style.spinner}>
      <Spin size="large" />
    </div>
  );
};

export default Loading;