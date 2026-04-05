import { NavLink } from 'react-router';

const Navigation = () => {
  return (
    <nav className="bg-gray-300 w-full h-16 flex items-center px-6">
      <div>
        <div>
          <NavLink
            to={'/'}
            className={({ isActive }) =>
              isActive ? 'text-lg font-semibold' : 'text-lg'
            }
          >
            Home
          </NavLink>
        </div>
      </div>
      <div className="flex-1"></div>
      <div className="flex gap-4">
        <NavLink
          to={'/Signin'}
          className={({ isActive }) =>
            isActive ? 'text-lg font-semibold' : 'text-lg'
          }
        >
          Signin
        </NavLink>
        <NavLink
          to={'/Signup'}
          className={({ isActive }) =>
            isActive ? 'text-lg font-semibold' : 'text-lg'
          }
        >
          Signup
        </NavLink>
      </div>
    </nav>
  );
};

export default Navigation;
