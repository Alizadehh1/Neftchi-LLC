import  { useState } from 'react';
import style from './index.module.scss';
import Logo from "../../assets/Logo.png";
import { IMenuData, menuData, optionsData } from './utils';
import { useNavigate } from 'react-router-dom';
import { Select } from 'antd';
import { GiHamburgerMenu } from "react-icons/gi";
import { useDispatch } from 'react-redux';
import { setScrollTarget } from '../../store/global';

const Header = () => {
    const navigate = useNavigate();
    const dispatch = useDispatch();

    const [openDropdown, setOpenDropdown] = useState<number | null>(null);

    const handleMouseEnter = (id: number) => {
        setOpenDropdown(id);
    };

    const handleMouseLeave = () => {
        setOpenDropdown(null);
    };

    const renderMenu = (menu: IMenuData) => {
        return (
            <div
                key={menu.id}
                className={style.menuItem}
                onMouseEnter={() => handleMouseEnter(menu.id)}
                onMouseLeave={handleMouseLeave}
            >
                <span className={window.location.pathname === menu?.link ? `${style.active}` : `${style.deactive}`} onClick={() => navigate(menu.link)}>{menu.value}</span>
                {menu.children && openDropdown === menu.id && (
                    <div className={style.dropdownMenu}>
                        {menu.children.map((child) => (
                            <div key={child.id} className={style.dropdownItem} onClick={() => {
                                navigate(child.link)
                                dispatch(setScrollTarget(child?.ref))
                            }}>
                                {child.value}
                            </div>
                        ))}
                    </div>
                )}
            </div>
        );
    };

    return (
        <div className={style.container}>
            <div className={style.hamburgerMenu}>
                <GiHamburgerMenu />
            </div>

            <figure onClick={() => navigate("/")}>
                <img src={Logo} alt="logo" />
            </figure>
            <div className={style.menu}>
                {menuData.map(renderMenu)}
            </div>
            <Select className={style.select} options={optionsData} />
        </div>
    );
};

export default Header;