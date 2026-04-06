import { NavLink } from 'react-router';

const Navigation = () => {
  return (
    <nav className="bg-background-main text-2xl text-text-primary w-full h-26 flex items-center px-6">
      <div>
        <div>
          <NavLink
            to={'/'}
            className={({ isActive }) =>
              isActive
                ? 'font-extrabold hover:text-text-secondary'
                : 'font-semibold hover:text-text-secondary'
            }
          >
            Home
          </NavLink>
        </div>
      </div>
      <div className="flex-1 border-"></div>
      <div className="flex gap-8">
        <NavLink
          to={'/Signin'}
          className={({ isActive }) =>
            isActive
              ? 'font-extrabold hover:text-text-secondary'
              : 'font-semibold hover:text-text-secondary'
          }
        >
          Signin
        </NavLink>
        <NavLink
          to={'/Signup'}
          className={({ isActive }) =>
            isActive
              ? 'font-extrabold hover:text-text-secondary'
              : 'font-semibold hover:text-text-secondary'
          }
        >
          Signup
        </NavLink>
      </div>
    </nav>
  );
};

export default Navigation;
