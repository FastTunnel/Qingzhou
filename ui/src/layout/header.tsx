export default function Header({ title }: { title: string | undefined }) {
    return <>
        <div className="h-16 border-b border-[#e7e5e4] flex px-6">
            <div><span className=" text-lg font-bold" style={{ lineHeight: '63px' }}>{title}</span></div>
            <div></div>
        </div>
    </>
}