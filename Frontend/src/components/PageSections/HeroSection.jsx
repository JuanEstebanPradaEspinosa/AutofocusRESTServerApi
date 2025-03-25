// eslint-disable-next-line no-unused-vars
import React from "react";

export default function HeroSection() {
  return (
    <div className="bg-white">
      <div className="relative isolate px-6 pt-14 flex gap-28 lg:px-8">
        <img
          src="src\images\BlueCar.jpg"
          alt="Blue car in garage"
          className="w-1/2 h-1/2" // Modified code: added "h-auto" to make the image height adjust automatically
        />
        <div>
          <div className="mx-auto max-w-2xl py-32 sm:py-48 lg:py-56">
            <div className="text-center">
              <h1 className="text-3xl font-bold tracking-tight text-gray-900 sm:text-5xl">
                Stel je auto beschikbaar!
              </h1>
              <p className="mt-6 text-lg leading-8 text-gray-600">
                Heb jij een unieke, klassieke, of opvallende auto die perfect
                zou passen in een film? Of misschien een alledaags voertuig dat
                een realistisch straatbeeld kan neerzetten? Hier is jouw kans om
                je auto te laten schitteren op het grote scherm én er geld mee
                te verdienen. Of je nu een vintage klassieker, een sportieve
                bolide, of een betrouwbare gezinswagen hebt, filmproducenten
                zijn altijd op zoek naar diverse auto&apos;s om hun producties
                tot leven te brengen.
              </p>
              <div className="mt-10 flex items-center justify-center gap-x-6">
                <a
                  href="#"
                  className="rounded-md bg-blue-600 px-3.5 py-2.5 text-sm font-semibold text-white shadow-sm hover:bg-blue-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-blue-600"
                >
                  Schrijf je in
                </a>
                <a
                  href="#"
                  className="text-sm font-semibold leading-6 text-gray-900"
                >
                  Meer info <span aria-hidden="true">→</span>
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
