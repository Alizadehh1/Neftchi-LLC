import { useState, useEffect } from "react";
import style from "./index.module.scss";
import Logo from "../../assets/Logo.png";
import { IMenuData, menuData, optionsData } from "./utils";
import { useNavigate } from "react-router-dom";
import { Select } from "antd";
import { GiHamburgerMenu } from "react-icons/gi";
import { useDispatch } from "react-redux";
import { setScrollTarget } from "../../store/global";
import { FiChevronDown, FiChevronUp } from "react-icons/fi";

const Header = () => {
    const navigate = useNavigate();
    const dispatch = useDispatch();

    const [openDropdown, setOpenDropdown] = useState<number | null>(null);
    const [mobileMenuOpen, setMobileMenuOpen] = useState(false);
    const [isMobile, setIsMobile] = useState(window.innerWidth <= 768);

    useEffect(() => {
        const handleResize = () => setIsMobile(window.innerWidth <= 768);
        window.addEventListener("resize", handleResize);
        return () => window.removeEventListener("resize", handleResize);
    }, []);

    const toggleMobileMenu = () => {

        setMobileMenuOpen((prev) => !prev);
    };

    const handleMouseEnter = (id: number) => {
        if (!isMobile) {
            setOpenDropdown(id);
        }
    };

    const handleMouseLeave = () => {
        if (!isMobile) {
            setOpenDropdown(null);
        }
    };

    const handleMenuClick = (id: number) => {
        if (isMobile) {
            setOpenDropdown((prev) => (prev === id ? null : id));
        }
    };

    const renderMenu = (menu: IMenuData) => {
        return (
            <div
                key={menu.id}
                className={style.menuItem}
                onMouseEnter={() => handleMouseEnter(menu.id)}
                onMouseLeave={handleMouseLeave}
                onClick={() => handleMenuClick(menu.id)}
            >
                <span
                    className={
                        window.location.pathname === menu?.link ? style.active : style.deactive
                    }
                    onClick={() => navigate(menu.link)}
                >
                    {menu.value}
                    {menu.children && (
                        <span className={style.arrowIcon}>
                            {openDropdown === menu.id ? (
                                <FiChevronUp style={{marginBottom : "-3px"}} />
                            ) : (
                                <FiChevronDown style={{marginBottom : "-3px"}} />
                            )}
                        </span>
                    )}
                </span>
                {menu.children && openDropdown === menu.id && (
                    <div className={style.dropdownMenu}>
                        {menu.children.map((child) => (
                            <div
                                key={child.id}
                                className={style.dropdownItem}
                                onClick={() => {
                                    navigate(child.link);
                                    dispatch(setScrollTarget(child?.ref));
                                }}
                            >
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
            <div className={style.hamburgerMenu} onClick={toggleMobileMenu}>
                <GiHamburgerMenu />
            </div>
            <figure onClick={() => navigate("/")}> <img src={Logo} alt="logo" /> </figure>
            <div className={`${style.menu} ${mobileMenuOpen ? style.open : ""}`}>{menuData.map(renderMenu)}</div>
            <Select className={style.select} options={optionsData} />
        </div>
    );
};

export default Header;