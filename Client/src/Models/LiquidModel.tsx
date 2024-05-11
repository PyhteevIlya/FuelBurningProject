interface LiquidFuelModel {
    c: number;
    h: number;
    s: number;
    n: number;
    o: number;
    wp: number;
    ap: number;
    t_v: number;
    t_t: number;
    alfaG: number;
    m_недожог: number;
    gg: number;
  }
  
  interface LiquidModel {
    name: string;
    description: string;
    typeCalculation: string;
    userId: number;
    isActive: boolean;
    liquidFuelModel: LiquidFuelModel;
  }