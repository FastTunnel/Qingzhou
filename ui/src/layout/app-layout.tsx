import React from 'react';
import Menu from './menu';
import { AppContent } from './app-content';
import Footer from './footer';

export const ELayout = {
  side: "side",
  fullPage: "fullPage",
}

export const SideLayout = React.memo(() => {

  return <>
    <div className="w-full h-full flex layout-has-sider ">
      <Menu></Menu>
      <div id='main' className="flex flex-col w-full h-full overflow-y-auto">
        <main className='flex flex-col w-full h-full relative'>
          <AppContent></AppContent>
          {/* <Footer></Footer> */}
        </main>
      </div>
    </div>
  </>;
})

export const FullPageLayout = React.memo(() => <AppContent />);

export default {
  [ELayout.side]: SideLayout,
};
