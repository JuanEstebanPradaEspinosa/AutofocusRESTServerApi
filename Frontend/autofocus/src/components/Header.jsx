import { NavLink } from "react-router-dom";
import { MdOutlineHome, MdOutlineBookmark } from "react-icons/md";

const Header = () => {
  return (
    <div className="flex justify-between items-center p-4 bg-emerald-800">
      <div className="flex items-center gap-8 mr-4">
        {
          <NavLink to="/" className="text-emerald-600">
            Home
            <div className="flex flex-col items-center">
              <MdOutlineHome />
            </div>
          </NavLink>
        }
        {
          <NavLink to="/catalogus" className="text-emerald-600">
            catalogus
            <div className="flex flex-col items-center">
              <MdOutlineBookmark />
            </div>
          </NavLink>
        }

        {
          <NavLink to="/contact" className="text-emerald-600">
            contact
            <div className="flex flex-col items-center">
              <MdOutlineBookmark />
            </div>
          </NavLink>
        }
        {
          <NavLink to="/login" className="text-emerald-600">
            login
            <div className="flex flex-col items-center">
              <MdOutlineBookmark />
            </div>
          </NavLink>
        }
        {
          <NavLink to="/registratie" className="text-emerald-600">
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
