import { Link } from "react-router-dom";

const Header = () =>{
    return(
        <div className="flex justify-between items-center p-4 bg-emerald-800">
            <div className="flex items-center gap-8 mr-4">
            {
                <NavLink
                to="/"
                activeClassName="text-white"
                className="text-emerald-600"
                >
                    Home
                    <div className="flex flex-col items-center">
                    <MdOutlineHome />
                    </div>
                </NavLink>
            }
            {
                <NavLink
                to="/catalogus"
                activeClassName="text-white"
                className="text-emerald-600"
              >
                catalogus
                <div className="flex flex-col items-center">
                  <MdOutlineBookmark />
                </div>
                </NavLink>

            }


            {
                <NavLink
                to="/contact"
                activeClassName="text-white"
                className="text-emerald-600"
                >
                    contact
                    <div className="flex flex-col items-center">
                      <MdOutlineBookmark />
                    </div>
                </NavLink>
            }
            {
                <NavLink
                to="/login"
                activeClassName="text-white"
                className="text-emerald-600"
              >
                login
                <div className="flex flex-col items-center">
                  <MdOutlineBookmark />
                </div>
                </NavLink>

            }
            {
                <NavLink
                to="/registratie"
                activeClassName="text-white"
                className="text-emerald-600"
              >
                registratie
                <div className="flex flex-col items-center">
                  <MdOutlineBookmark />
                </div>
                </NavLink>

            }
            </div>

        </div>
    );
};
export default Header;